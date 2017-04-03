/*
    This file is part of the iText (R) project.
    Copyright (c) 1998-2017 iText Group NV
    Authors: iText Software.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS
    
    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
    http://itextpdf.com/terms-of-use/
    
    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
    
    In accordance with Section 7(b) of the GNU Affero General Public License,
    a covered work must retain the producer line in every PDF that is created
    or manipulated using iText.
    
    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the iText software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving PDFs on the fly in a web application, shipping iText with a closed
    source product.
    
    For more information, please contact iText Software Corp. at this
    address: sales@itextpdf.com
 */
using System;
using iTextSharp.text.error_messages;

namespace iTextSharp.text.pdf {

    /**
     * A <CODE>PdfICCBased</CODE> defines a ColorSpace
     *
     * @see        PdfStream
     */

    [Obsolete("For internal use only. If you want to use iText, please use a dependency on iText 7. ")]
    public class PdfICCBased : PdfStream {
    
        /**
        * Creates an ICC stream.
        * @param   profile an ICC profile
        */
        public PdfICCBased(ICC_Profile profile) : this(profile, DEFAULT_COMPRESSION) {
            ;
        }
        
        /**
        * Creates an ICC stream.
        *
        * @param   compressionLevel    the compressionLevel
        *
        * @param   profile an ICC profile
        * @since   2.1.3   (replacing the constructor without param compressionLevel)
        */
        public PdfICCBased(ICC_Profile profile, int compressionLevel) {
            int numberOfComponents = profile.NumComponents;
            switch (numberOfComponents) {
                case 1:
                    Put(PdfName.ALTERNATE, PdfName.DEVICEGRAY);
                    break;
                case 3:
                    Put(PdfName.ALTERNATE, PdfName.DEVICERGB);
                    break;
                case 4:
                    Put(PdfName.ALTERNATE, PdfName.DEVICECMYK);
                    break;
                default:
                    throw new PdfException(MessageLocalization.GetComposedMessage("1.component.s.is.not.supported", numberOfComponents));
            }
            Put(PdfName.N, new PdfNumber(numberOfComponents));
            bytes = profile.Data;
            Put(PdfName.LENGTH, new PdfNumber(bytes.Length));
            FlateCompress(compressionLevel);
        }
    }
}
