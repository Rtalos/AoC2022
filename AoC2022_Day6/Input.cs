﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022_Day6
{
    public static class Input
    {
        public static string sequence = "bhzhtzzsczszsjjjzddfzdfzfjfzfbbnntnzznwzzvfvrrqmrmmdzzfqfhqhsqqpwpgwpppbtbnnstthmhrrsmmvsmmhjmjfmfsfjfnfnjjvcjjszjszjsszbznzbnzndzzmlldsdgdcddmqmfqqlcllbvllztzctzczdzttlmtlthtmhtmhmmszsllvzvdzzzsqzqbqccvfvcffzsfslfsllcglclwlvwvzzdsslggtzzgzdzmzddjljvvztttsgscsstztjztjztzvzwwthtftppnmpmmcpmmjlmjjjsfjsjppgcgwcggzffzwzbbmbrbprpqqpccfncfnffvcffsqqtzqzqwzwvzwwwbjbfbcbfblltnlnhhcthtvvzzfcfgfddlggbbshsggplglqqbrbggsvvzdvvlfvlvpvhhmggbrrnppjfjhffttfpffbdfbfvfqvvtcvvbvnnhbhhglgjgzzghhwrrtntrtwwfdfdmmcmtctftpptllzqllzflfrrgqgvgdvdfdbddprrrgccqvqnnmtmvmffpzzqggfbfnfwwqdqldqqlnqnttnbttrffnmmzwzjjtrjtrtmmqsmqmffqmfqfhhbthbhdhvdhvdvmvdmdhdshsqslldzztvvmzzdcccmbbhfhshrrrpsrrqqmdmmgdmmwdmdjdqqmcmttpgtgwgpwpprbrprhrsrllhsllprlplhppfzpffbhbccwdwbbrpbpvpqqmsspjssmbbmfmrmnrnwwgbwwbpwpjwwhqqgcqcvqccgffzpfftcffqlqjjznnlflhhlcczhzvhzhmzhmhfhnnqznntstwtggqjgjhggsvslltjlttfjjgffjzjwzzqzrrhlhzhbhphmhlmlzmzsmzmccvllgrrpbrbfbjfjttqjttdrdhhggqgddppqgpqgpgtptjptpllwccmwcmcpmcppdrrtstqqczqzvvlsltlddnvdvggcqqblqqsjqjttzhtzzszllqsqfqddqdbqddwqddfzzlczcscfsfpfdpdrpddsggcqchcfcpcssstwstwtggghvhqhzzqssjddwjwbjjsnjnfnwwglwwfnfhnnscsggzgjzzhzmmqfqsqwqrwqqqdtdcttzvvnbngbbcdbdggddnmddgzghhzgghwwbjbttlwlcctlccwwdhhrqrvrjjlglssgttpllwclwwtptwptwtvthtbhbzhbzhhrsrwwwnrwrfwfnwnhhnqqdjqjpqqwdwttzhttcdttvztzltzlzmzddrsdsfdsfftdfffmwffrjrffqrfqfsfqqqgqjggwzzrnnqfnqffdbfbtbbrpbrpbptpwttjmjjzrrhhqppdzdtdjttqwwtddjdzzmgzzhwwwdsdgssprsrgsgbbphhdpdwppnfppdqqwzzpbzzqwqpqsqhqdhqqtwwjnnmvmwvmmwwgjgzjjvcjcvcjcnjcncmmphmmvmwmwpwbbtbffhnhshgssgvgvrrbwbtbddqmqfqvvfqvqdvvdbvdbdcdfdlflmffrwwgmmttrztrrfrqrpqrrzjrjpjdpjprrnhhbhcbbcwwqlwwcssbddfrfjrfjfrjfjvvdmdtdzzlvzlzhzmhmhphchnnfqnffvccfpfbfpfqpprrmttzrzzjzmjmzjmmfvmmrzrqqdllgjlglcchssgllsbllrbrlrjlrrhhfwwsqwsstpssznzcznzqzssvtvtrrqwqvvtssgfsfhssljjnwjnjddjdggclcrrfsfhsstgtdtctfttvvsbvvbtbttcgcssjlslhlpljpppwzwnwdnngmgjjbzznwwdllrrfppshhvdhhldhdbbdbjbdjjrnjjzhzfhhsqqbqgmsbvnjsptlrsszlqfmgprvscphmqztbgtlrqvcgdzcptcqjncrdtfqnghnbmwwmcjgtjlbvqqzslgbbntrdfnvfjvfgcgngndjcspgwmpnsrqzzvzljbzlzzrwflrqqqmhsvqwbmdftnhwwzgqrlhddbbtwvbphljmstcjzvpjqwcnhlvpqvqdgvntgqzqwrlwbwvngwtqgrhznlzcvbwqmwncccjctrdzrmzjsvrmcfpjjcczhbvdfwhqvczggfmrspvprvvthvtqnsphpcsdmbrtbdqljvssdrhwjsrrlzprstpgqcbpmnpdgzgjttwcfrgjnsghmszlclgvmlsjrqfvflbnhwwphtvrnrbhdvdglcvgpzfsjpwwhtlvvdzthsrldfzhnlrblzsjjnwclqsqzgdbflhvpwcrtfbfbjcjttbjpvfgvfcswnqqwshbmqlscdzzwshfqwsvwnwzltbnrmzzhzvtwpzqcgwshpvzgtcmwrtrwctnpzbznnwqphnrgwljtrcwlqmvlndwrdrctztnmswslqmbjcmtlrmcpjvzccqszrnflqnqzttbhqlrhbmqdpscqvfgtdbnwjdcljwcbgbgjfzgrgpwqzqgbnrtpntfthhdbqmswvhnmwmszpghgjjzrbnbbfjblpstdfslmmmqfdcrhblqjqfphnldrvvfpnfrcvprjnqbzbspfpjtgqhnjbhnrwzcjvdbshhqpgrmzqpmjfmqwqvvdbddbsldwzzsrhnhsjjnvljrbwcnjrnjpmrrvfthftgptgtlpbgqffthflgftwcrqcqwqwrmrcmfrcqgmrnqjbscdcgrqlhjzthvzdgjbvpswflqcgsnlmgmvcsttsgmnqdtvwdvrndvfdcvrcwmqlmlhtrvthsndsrmnsfmdmfnpfmfhzjqmtcjzcrnsjdztztvgdtlrmbdmmstbfgpmmzthcslpvgrpgfljfgqlqhldfwvvvdvbzjtdtppbtrnqwsqztjrsjhtfrgmvsdngvsdzjgpwrldqpzdpvhljzpjvttwltdwcrhcbrgrvdrmpwvdwjchqsjfprbgtjtzggvgrgmlvvwqrjfprbbgjjqrtdfnrdffwbswbvqtqtfsrhsgrjhftqldhmcnmsnfflmdrzqdjmbqqgqsttdmtrrvfsjnccnhcpcvqtrzdjzrpwswmjvvgsgwvnmdgqwlctrlhqnsmczbwsjhmtgvdcgsndzlstcwchcztqqbtdwfvlljdvdlzljslgnzpmqvzfcvqhdzvgchffqgfwrnmwqzwgbzblpmvddlvnhglrhdnwzqwztzgjczjpwcjwmpnrnrhncfjfggrbphrjztwtfqmfjlwfhnqfftfghbnvtwgtmdzzrdrtmfrwhrrbhzmcllsgqzwzzqtgdggvzptvtdcpzmtmsfcfbjtzlbdrwhdbtdhhrgggmddnzsvjwgcdcqfppqwphfvlhmgqsznlhmgpnjvcvrwwppnphchgsrhjwjcpjggsrcwrvnllfgrmjltfzwhmbqwpwwzmrtlqcprrqztcgnghcbvzrbfptjmhtdcfhhffdbrswqpnpppnpqwtflrrmqgjzctmmvvvwzllbsfdvpqjtmvpjcpmjztscsgbdznfgcmtjzdqzwqrsvstnnvddcstzqjtnbsnlptpmbmfqmhppgnjrffqrtchgptbmwlwbwbcqqfngpbwtwdmlmdstmqwcwjtbwbbbhghgptmvhfmvqfvpwqzwnbjdhpwlgjgvprdjbnlzhnllssbpvzfzspwsscfpqtpdvtzvqncfrfrgddsdglqvpblmpcczlqfdmwzmgvrljhqtcglcvfhbdwhbttqqrjbqwhsrhrbjwmtqwqddvdggdwfsmnpbpvvgsqnvvrqntwmbzdnqpmmqtbnlsbmslpfmqjtgvbddhwvlvjtlrhqdpfnjwtbhwjwdrpgctbbrdqvbbnvgqwngrhqfvwzmlqtmhfqphnmczlbdpnbmpvwrsjbcnjnvcfgnsvlhpzdgdzgvfbgwdcrswznrggnghzssdwqvvlwftqhbnwdvghhvjlqqmcnqmvbwhrrnsswlwmwbsmpcpdzzgmcmqnzpvjpzqbwcsgdhqtqhcpbtqftvscmntsbdcbrndvlfhprpblzbjcpqhfljtvnvtgvrcgqbsgl";
    }
}
